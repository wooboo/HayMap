using System;
using HayMap.Automapper;
using HayMap.EnumMapper;
using HayMap.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HayMap.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var someObject = new SomeType()
            {
                Value = 312
            };
            var enum1 = SomeEnum.One;
            var enum2 = SomeOtherEnum.Zero;
            SomeEnum? enum3 = SomeEnum.One;
            SomeOtherEnum? enum4 = SomeOtherEnum.Zero;
            SomeEnum? enum5 = null;
            SomeOtherEnum? enum6 = null;

            var someOtherObject1 = new SomeOtherType(3);
            var someOtherObject2 = new SomeOtherType(3);
            var someOtherObject3 = new SomeOtherType(3);
            var someOtherObject4 = new SomeOtherType(3);
            var mapper = new SomeOtherCreatingAndUpdatingMapper();

            var res1 = mapper.Create(someObject);
            mapper.Update(someObject, res1);
            ICreatingMapper<SomeType, SomeOtherType> dynamicMapper = new DynamicMapper<SomeType, SomeOtherType>(AutoMapper.Mapper.Engine);
            ICreatingMapper<SomeEnum, SomeOtherEnum> enumMapper = new CreatingEnumMapper<SomeEnum, SomeOtherEnum>(SomeOtherEnum.Zero);

            dynamicMapper.Create(someObject);
            enumMapper.Create(enum1);
            SomeOtherType r1 = someObject.Using(mapper).Create();
            SomeOtherType r2 = someObject.Using(mapper).Update(someOtherObject1);

            SomeOtherType r3 = someObject.Using(new SomeOtherCreatingMapper()).Create();
            SomeOtherType r4 = someObject.Using(new SomeOtherUpdatableMapper()).Update(someOtherObject2);
            SomeOtherSimpleType r4s = someObject.UsingUpdater(new SomeOtherSimpleUpdatableMapper()).Create();

            SomeOtherType r5 = someObject.UsingDynamicMapper<SomeOtherType>().Create();
            SomeOtherType r6 = someObject.UsingDynamicMapper<SomeOtherType>().Update(someOtherObject3);

            SomeOtherType r7 = someObject.UsingAutoMapper<SomeOtherType>().Create();
            SomeOtherType r8 = someObject.UsingAutoMapper<SomeOtherType>().Update(someOtherObject4);

            SomeOtherType r9 = someObject.Using((t) => new SomeOtherType(t.Value)).Create();
            SomeOtherType r10 = someObject.Using((SomeType t, SomeOtherType d) => d.UpdateOtherValue(t.Value)).Update(someOtherObject2);
            SomeOtherSimpleType r10s = someObject.UsingUpdater((SomeType t, SomeOtherSimpleType d) => d.OtherValue = t.Value).Create();

            SomeOtherType r11 = someObject.Using(MapCreate).Create();
            SomeOtherType r12 = someObject.Using<SomeType, SomeOtherType>(MapUpdate).Update(someOtherObject2);


            var resEnum01 = enum1.UsingEnumMapper<SomeEnum, SomeOtherEnum>().Create();
            try
            {
                var resEnum02 = enum2.UsingEnumMapper<SomeOtherEnum, SomeEnum>().Create();
            }
            catch { }
            var resEnum03 = enum3.UsingEnumMapper<SomeEnum?, SomeOtherEnum>().Create();
            try
            {
                var resEnum04 = enum4.UsingEnumMapper<SomeOtherEnum?, SomeEnum>().Create();
            }
            catch { }
            try
            {
                var resEnum05 = enum5.UsingEnumMapper<SomeEnum?, SomeOtherEnum>().Create();
            }
            catch { }
            try
            {
                var resEnum06 = enum6.UsingEnumMapper<SomeOtherEnum?, SomeEnum>().Create();
            }
            catch { }

            var resEnum11 = enum1.UsingEnumMapperWithDefault(SomeOtherEnum.Two).Create();
            var resEnum12 = enum2.UsingEnumMapperWithDefault(SomeEnum.Two).Create();
            var resEnum13 = enum3.UsingEnumMapperWithDefault(SomeOtherEnum.Two).Create();
            var resEnum14 = enum4.UsingEnumMapperWithDefault(SomeEnum.Two).Create();
            var resEnum15 = enum5.UsingEnumMapperWithDefault(SomeOtherEnum.Two).Create();
            var resEnum16 = enum6.UsingEnumMapperWithDefault(SomeEnum.Two).Create();

        }
        private static SomeOtherType MapCreate(SomeType source)
        {
            return new SomeOtherType(source.Value);
        }
        private static void MapUpdate(SomeType source, SomeOtherType dest)
        {
            dest.UpdateOtherValue(source.Value);
        }

    }
    
}
